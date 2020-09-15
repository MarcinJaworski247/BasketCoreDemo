<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Zawodnicy
        <DxButton
            type="success"
            styling-mode="outlined"
            text="Dodaj"
            class="float-right"
            @click="showAddPopup()">
        </DxButton> 
        </h3>
        
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="getPlayers"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        
        <DxColumn 
            data-field="firstName"
            data-type="string"
            alignment="left"
            caption="Imię" />
        <DxColumn 
            data-field="lastName"
            data-type="string"
            alignment="left"
            caption="Nazwisko" />
        <DxColumn 
            data-field="positionName"
            alignment="left"
            caption="Pozycja" />
        <DxColumn 
            data-field="number"
            data-type="number"
            alignment="center"
            caption="Numer" />
        <DxColumn 
            data-field="height"
            data-type="number"
            alignment="center"
            caption="Wzrost [cm]" />
        <DxColumn 
            data-field="weight"
            data-type="number"
            alignment="center"
            caption="Waga [kg]" />
        <DxColumn 
            data-field="birthDate"
            alignment="right"
            data-type="date"
            caption="Data urodzenia" />
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
            @click="deletePl()" />
    </DxPopup>

    <!-- Add popup -->

    <DxPopup
        :visible.sync="addPopupVisible"
        :drag-enabled="false"
        :show-title="true"
        title="Dodaj zawodnika"
        width="600"
        height="600">

        <div class="form-group">
            <label>Imię</label>                
            <DxTextBox v-model="add_firstName" />
            <label>Nazwisko</label>    
            <DxTextBox v-model="add_lastName" />
            <label>Wzrost [cm]</label>    
            <DxNumberBox v-model="add_height" />
            <label>Waga [kg]</label>    
            <DxNumberBox v-model="add_weight" />
            <label>Numer na koszulce</label>    
            <DxNumberBox v-model="add_number" />
            <label>Data urodzenia</label>    
            <DxDateBox v-model="add_birthDate" />
            <label>Pozycja</label>    
            <DxSelectBox
                :items="positions" 
                v-model="add_position"
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
            @click="add()" />
    </DxPopup>

    <!-- Edit popup -->
    <DxPopup
        :visible.sync="editPopupVisible"
        :drag-enabled="false"
        :shot-title="true"
        title="Edycja zawodnika"
        width="600"
        height="600">

        <div class="form-group">
            <label>Imię</label>                
            <DxTextBox v-model="firstName" />
            <label>Nazwisko</label>    
            <DxTextBox v-model="lastName" />
            <label>Wzrost [cm]</label>    
            <DxNumberBox v-model="height" />
            <label>Waga [kg]</label>    
            <DxNumberBox v-model="weight" />
            <label>Numer na koszulce</label>    
            <DxNumberBox v-model="number" />
            <label>Data urodzenia</label>    
            <DxDateBox v-model="birthDate" />
            <label>Pozycja</label>    
            <DxSelectBox
                :items="positions" 
                v-model="position"
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
            @click="edit()" />
    </DxPopup>
    
</div>
</template>

<script>
import { DxDataGrid, DxColumn, DxFilterRow } from 'devextreme-vue/data-grid';
import { DxPopup } from 'devextreme-vue/popup';
import DxButton from 'devextreme-vue/button';
import { DxTextBox, DxNumberBox, DxDateBox, DxSelectBox } from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapMutations } from "vuex";

export default {
    name: "lineup",
    data() {
        return { 
            deletePopupVisible: false,
            addPopupVisible: false,
            editPopupVisible: false
        }
    },
    created() {
        this.setPositions();
    },
    computed: {
        ...mapGetters('lineupStore', [
            'getEditForm', 
            'getAddForm', 
            'getPlayers', 
            'getPositions'
        ]),
        ...mapFields('lineupStore', 
            [
                'positions', 
                'players', 
                'idToDelete',
                'editForm.firstName',
                'editForm.lastName',
                'editForm.height',
                'editForm.weight',
                'editForm.birthDate',
                'editForm.position',
                'editForm.number',
                'editForm.id',
                'addForm.add_firstName',
                'addForm.add_lastName',
                'addForm.add_height',
                'addForm.add_weight',
                'addForm.add_birthDate',
                'addForm.add_position',
                'addForm.add_number'
            ])
    },
    methods: {
        ...mapActions('lineupStore', ['setDetails', 'setPositions', 'setPlayers', 'editPlayer', 'deletePlayer', 'addPlayer']),
        ...mapMutations('lineupStore', ['resetEditForm', 'resetAddForm']),
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
        showEditPopup(data) {
            this.setDetails(data.value)
            this.editPopupVisible = true;
        },
        hideEditPopup() {
            this.editPopupVisible = false;
            this.resetEditForm();
        },
        edit() {
            this.editPlayer()
                .then(() => {
                    this.setPlayers();
                }); 
            this.hideEditPopup();
            this.showSuccessNotify();
            this.resetEditForm();
        },
        deletePl() {
            this.deletePlayer()
                .then(() => {
                    this.setPlayers();
                });
            this.deletePopupVisible = false;
            this.showDeletedNotify();
            this.idToDelete = null;
        },
        add() {
            this.addPlayer()
                .then(() => {
                    this.setPlayers();
                });
            this.addPopupVisible = false;
            this.showSuccessNotify();
            this.resetAddForm();
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
        this.setPlayers();
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxPopup,
        DxTextBox,
        DxDateBox,
        DxNumberBox,
        DxSelectBox,
        DxButton,
        DxFilterRow
    }
};
</script>