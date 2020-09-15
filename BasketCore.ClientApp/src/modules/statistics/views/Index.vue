<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Średnie statystyki
        </h3>
        
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="avgStats"
        :show-borders="true"
        key-expr="playerId"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
         @exporting="onExporting"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxExport :enabled="true" />
        <DxColumn 
            data-field="playerId"
            alignment="left"
            caption="Imię i nazwisko">
            <DxLookup
                :data-source="playersLookup"
                value-expr="value"
                display-expr="text" />
        </DxColumn>
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
    </DxDataGrid>
    
    </div>

   
    
</div>
</template>

<script>
import { DxDataGrid, DxColumn, DxFilterRow, DxExport, DxLookup } from 'devextreme-vue/data-grid';
import service from "../services/statisticsService.js";
import ExcelJS from 'exceljs';
import { exportDataGrid } from 'devextreme/excel_exporter';
import saveAs from 'file-saver';


export default {
    name: "lineup",
    data() {
        return {
            avgStats: [],
            playersLookup: []
        }
    },
    created() {
        this.getPlayersLookup();
    },
    methods: {
        getAvgStats() {
            service.getAvgStats()
                .then(response => {
                    this.avgStats = response.data;
            });
        },
        onExporting(e) {
            const workbook = new ExcelJS.Workbook();
            const worksheet = workbook.addWorksheet('Main sheet');
            exportDataGrid({
                component: e.component,
                worksheet: worksheet,
                customizeCell: function(options) {
                    const excelCell = options;
                    excelCell.font = { name: 'Arial', size: 12 };
                    excelCell.alignment = { horizontal: 'left' };
                } 
            }).then(function() {
                workbook.xlsx.writeBuffer()
                    .then(function(buffer) {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'DataGrid.xlsx');
                    });
            });
            e.cancel = true;
        },
        getPlayersLookup() {
            service.getPlayersToLookup()
                .then(response => {
                    this.playersLookup = response.data;
            })
        }       
    },
    mounted() {
        this.getAvgStats();
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxFilterRow,
        DxExport,
        DxLookup
    }
};
</script>