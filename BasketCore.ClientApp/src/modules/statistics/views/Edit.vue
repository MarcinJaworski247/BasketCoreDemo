<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Statystyki meczu z {{ this.getOpponentName }}
        </h3>
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="stats"
        :show-borders="true"
        key-expr="playerId"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        
        <DxColumn 
            data-field="name"
            data-type="string"
            alignment="left"
            caption="Imię i nazwisko" />
        <DxColumn 
            data-field="points"
            data-type="number"
            alignment="center"
            caption="Punkty" />
        <DxColumn 
            data-field="assists"
            data-type="number"
            alignment="center"
            caption="Asysty" />
        <DxColumn 
            data-field="rebounds"
            data-type="number"
            alignment="center"
            caption="Zbiórki" />
        <DxColumn 
            data-field="steals"
            data-type="number"
            alignment="center"
            caption="Przechwyty" />
        <DxColumn 
            data-field="blocks"
            data-type="number"
            alignment="center"
            caption="Bloki" />
        <DxColumn 
            data-field="fauls"
            data-type="number"
            alignment="center"
            caption="Faule" />
        
        <DxColumn 
            data-field="playerId"
            caption="" 
            :allow-sorting="false"
            :allow-search="false"
            alignment="center"
            cell-template="customCell"
            width="100" />
        <div slot="customCell" slot-scope="{ data }">
            <span @click="showEditPopup(data)" title="Edycja" class="fas fa-chevron-right" />
        </div>
    </DxDataGrid>
    
    </div>

    <!-- Edit popup -->
    <DxPopup
        :visible.sync="editPopupVisible"
        :drag-enabled="false"
        :shot-title="true"
        title="Edycja"
        width="500"
        height="540">

        <div class="form-group">
            <h4>{{name}}</h4>
            <label>Punkty</label>    
            <DxNumberBox v-model="points" />
            <label>Asysty</label>    
            <DxNumberBox v-model="assists" />
            <label>Zbiórki</label>    
            <DxNumberBox v-model="rebounds" />
            <label>Przechwyty</label>    
            <DxNumberBox v-model="steals" />
            <label>Bloki</label>    
            <DxNumberBox v-model="blocks" />
            <label>Faule</label>    
            <DxNumberBox v-model="fauls" />
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
            @click="editS()" />
    </DxPopup>
    
</div>
</template>

<script>
import { DxDataGrid, DxColumn, DxFilterRow } from 'devextreme-vue/data-grid';
import { DxPopup } from 'devextreme-vue/popup';
import DxButton from 'devextreme-vue/button';
import { DxNumberBox } from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapMutations } from "vuex";


export default {
    name: "stats",
    data() {
        return {
            editPopupVisible: false
        }
    },
    created() {
        this.setOpponentName(this.$route.params.gameId);
    },
    computed: {
        ...mapGetters('statsStore', [
            'getEditForm', 
            'getStats', 
            'getOpponentName'
        ]),
        ...mapFields('statsStore', 
            [
                'stats', 
                'opponentName', 
                'editForm.name',
                'editForm.playerId',
                'editForm.gameId',
                'editForm.points',
                'editForm.assists',
                'editForm.rebounds',
                'editForm.steals',
                'editForm.blocks',
                'editForm.fauls'
            ])
    },
    methods: {
        ...mapActions('statsStore', ['setDetails', 'setStats', 'setOpponentName', 'editStats']),
        ...mapMutations('statsStore', ['resetEditForm']),
        showEditPopup(data) {
            debugger
            this.setDetails(data.value)
                .then(() => {
                    this.editPopupVisible = true;
                });
        },
        hideEditPopup() {
            this.editPopupVisible = false;
            this.resetEditForm();
        },
        editS() {
            debugger
            this.editStats()
                .then(() => {
                    this.setStats();
                    this.hideEditPopup();
                    this.showSuccessNotify();
            });
        },
        showSuccessNotify() {
            this.$nextTick(() => {
            notify("Zapisano", "success", 500);
            })
        }     
    },
    mounted() {
        this.setStats(this.$route.params.gameId);
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxPopup,
        DxNumberBox,
        DxButton,
        DxFilterRow
    }
};
</script>
<style scoped>
.dx-toolbar-label .dx-toolbar-item-content > div {  
    overflow: visible;  
}  
</style>