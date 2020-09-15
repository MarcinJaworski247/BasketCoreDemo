<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Mecze
        <DxButton
            type="success"
            styling-mode="outlined"
            class="float-right"
            text="Dodaj"
            @click="showAddPopup()">
        </DxButton> 
        </h3>
        
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="games"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        
        <DxColumn 
            data-field="opponentName"
            data-type="string"
            alignment="left"
            caption="Przeciwko" />
        <DxColumn 
            data-field="court"
            data-type="string"
            alignment="left"
            caption="Arena" />
        <DxColumn 
            data-field="gameTypeName"
            data-type="string"
            alignment="left"
            caption="Typ" />
        <DxColumn 
            data-field="date"
            data-type="date"
            alignment="right"
            caption="Data" />
        <DxColumn 
            data-field="id"
            caption="" 
            :allow-sorting="false"
            :allow-search="false"
            alignment="center"
            cell-template="customCell"
            width="100" />
        <div slot="customCell" slot-scope="{ data }">
            <span @click="showEditPopup(data)" title="Edycja" class="fas fa-chevron-right" />
            <span @click="showDeletePopup(data)" title="Usuń" class=" ml-3 fas fa-trash" />
            <router-link :to="{ name: `statistics.edit`, params: { gameId: data.value } }">
                <span class="ml-3 fas fa-chart-bar" style="color: black;" title="Dodaj statystyki"></span>
            </router-link>
        </div>
    </DxDataGrid>
    
    </div>

    <!-- Delete popup -->

    <DxPopup
        :visible.sync="deletePopupVisible"
        :drag-enabled="false"
        :show-title="true"
        title="Czy na pewno usunąć?"
        height="150"
        width="280">
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideDeletePopup()" />
        <DxButton
            text="Usuń"
            type="danger"
            styling-mode="outlined"
            @click="deleteG()" />
    </DxPopup>

    <!-- Add popup -->

    <DxPopup
        :visible.sync="addPopupVisible"
        :drag-enabled="false"
        :show-title="true"
        title="Dodaj mecz"
        width="600"
        height="400">

        <div class="form-group">
            <label>Przeciwnik</label>                
            <DxTextBox v-model="add_opponentname" />
            <label>Data</label>    
            <DxDateBox v-model="add_date" />
            <label>Nazwa areny</label>    
            <DxTextBox v-model="add_court" />
            <label>Rodzaj meczu</label>    
            <DxSelectBox
                :items="gameTypes" 
                v-model="add_gametype"
                :show-clear-button="true"
                value-expr="value"
                display-expr="text"
                placeholder=""
                key="value" />
        </div>      
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideAddPopup()" />
        <DxButton
            text="Dodaj"
            type="success"
            styling-mode="outlined"
            @click="addG()" />
    </DxPopup>

    <!-- Edit popup -->
    <DxPopup
        :visible.sync="editPopupVisible"
        :drag-enabled="false"
        :shot-title="true"
        title="Edycja meczu"
        width="600"
        height="400">

        <div class="form-group">
            <label>Przeciwnik</label>                
            <DxTextBox v-model="opponentName" />
            <label>Data</label>    
            <DxDateBox v-model="date" />
            <label>Nazwa areny</label>    
            <DxTextBox v-model="court" />
            <label>Rodzaj meczu</label>    
            <DxSelectBox
                :items="gameTypes" 
                v-model="gameType"
                :show-clear-button="true"
                value-expr="value"
                display-expr="text"
                placeholder=""
                key="value" />
        </div>      
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideEditPopup()" />
        <DxButton
            text="Zapisz"
            type="success"
            styling-mode="outlined"
            @click="editG()" />
    </DxPopup>
    
</div>
</template>

<script>
import { DxDataGrid, DxColumn, DxFilterRow } from 'devextreme-vue/data-grid';
import { DxPopup } from 'devextreme-vue/popup';
import DxButton from 'devextreme-vue/button';
import { DxTextBox, DxDateBox, DxSelectBox } from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import service from "../services/gamesService.js";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapMutations } from "vuex";

export default {
    name: "games",
    data() {
        return {
            deletePopupVisible: false,
            addPopupVisible: false,
            editPopupVisible: false
        }
    },
    created() {
        this.setGameTypes();
    },
    computed: {
        ...mapGetters('gamesStore', [
            'getEditForm', 
            'getAddForm', 
            'getGames', 
            'getGameTypes'
        ]),
        ...mapFields('gamesStore', 
            [
                'games', 
                'gameTypes', 
                'idToDelete',
                'editForm.opponentName',
                'editForm.date',
                'editForm.court',
                'editForm.gameType',
                'editForm.id',
                'addForm.add_opponentname',
                'addForm.add_date',
                'addForm.add_court',
                'addForm.add_gametype'
            ])
    },
    methods: {
        ...mapActions('gamesStore', ['setDetails', 'setGameTypes', 'setGames', 'editGame', 'deleteGame', 'addGame']),
        ...mapMutations('gamesStore', ['resetEditForm', 'resetAddForm']),
        showDeletePopup(data) {
            this.deletePopupVisible = true;
            this.idToDelete = data.value;
        },
        hideDeletePopup() {
            this.deletePopupVisible = false;
            this.idToDelete = null;
        },
        showAddPopup() {
            this.addPopupVisible = true;
        },
        hideAddPopup() {
            this.addPopupVisible = false;
        },
        addG() {
            debugger
            this.addGame()
                .then(() => {
                    this.resetAddForm();
                    this.setGames();
                    this.showSuccessNotify();
                    this.addPopupVisible = false;
                });
        },
        deleteG() {
            this.deleteGame()
                .then(() => {
                    this.setGames();
                    this.deletePopupVisible = false;
                    this.showDeletedNotify();
                    this.idToDelete = null;
                })
        },
        showEditPopup(data) {
            this.setDetails(data.value);
            this.editPopupVisible = true;
        },
        hideEditPopup() {
            this.editPopupVisible = false;
            this.resetEditForm();
        },
        editG() {
            this.editGame(this.editForm)
                .then(() => {
                    this.hideEditPopup();
                    this.setGames();
                    this.showSuccessNotify();
            });
        },
        showSuccessNotify() {
            this.$nextTick(() => {
            notify("Zapisano", "success", 500);
            })
        },
        showDeletedNotify() {
            this.$nextTick(() => {
            notify("Usunięto", "warning", 500);
            })
        }        
    },
    mounted() {
        this.setGames();
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxPopup,
        DxTextBox,
        DxDateBox,
        DxSelectBox,
        DxButton,
        DxFilterRow
    }
};
</script>