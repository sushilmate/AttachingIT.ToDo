import { Component, Inject, ViewChild, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToDoViewModel } from '../../Shared/todo-viewmodel';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  columnDefs = [
    { headerName: 'Id', field: 'id', editable: false, width: 80 },
    { headerName: 'Name', field: 'name', editable: true },
    {
      headerName: 'Status',
      field: 'status',
      editable: true
    },
    {
      headerName: 'Complete',
      field: 'complete',
      editable: false,
      cellRenderer: params => {
        return `<input type='checkbox' ${params.value ? 'checked' : ''} />`;
      }
    }
  ];
  public rowData: ToDoViewModel[];
  arrayBuffer: any;
  file: File;
  private gridApi;
  private overlayLoadingTemplate;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
  }

  ngOnInit() {
    this.overlayLoadingTemplate =
      '<span class="ag-overlay-loading-center"><i class="fa fa-refresh fa-spin" style="font-size:24px;color:cornflowerblue"></i></span>';
    this.GetAllToDos();
  }

  AddToDo() {
    var newItem = new ToDoViewModel();
    newItem.id = 0;
    newItem.name = "";
    newItem.newOrModified = "new";
    newItem.status = "Open";
    newItem.complete = true;
    this.gridApi.updateRowData({ add: [newItem] });
    this.gridApi.setFocusedCell(this.gridApi.getDisplayedRowCount() - 1, "name");
  }

  DeleteToDo() {
    this.gridApi.showLoadingOverlay();
    var selectedData = this.gridApi.getSelectedRows();
    var filteredData = selectedData.filter(x => x.id != 0);
    if (filteredData.length > 0) {
      this.http.post(this.baseUrl + 'api/ToDodata/RemoveToDo', filteredData, httpOptions).subscribe(result => {
        //this.gridApi.hideOverlay();
        this.gridApi.updateRowData({ remove: selectedData });
      },
        error => console.log('There was an error: '));
    } else {
      this.gridApi.updateRowData({ remove: selectedData });
      this.gridApi.hideOverlay();
    }
  }

  onGridReady(params) {
    this.gridApi = params.api;
  }

  SaveToDoServer() {
    //var res = this.gridApi.updateRowData({ update: null });
    var newOrModifiedToDos: ToDoViewModel[] = [];

    this.gridApi.forEachNode(function (node) {
      //console.log(node.data);
      if (node.data.newOrModified == "new" || node.data.newOrModified == "modified") {
        newOrModifiedToDos.push(node.data);
      }
    });
    if (newOrModifiedToDos.length > 0) {
      this.http.post<ToDoViewModel[]>(this.baseUrl + 'api/ToDodata/UpdateOrAddToDo', newOrModifiedToDos, httpOptions)
        .subscribe(result => {
          this.rowData = result;
        },
          error => console.log('There was an error: '));
    }
  }

  GetAllToDos() {
    //this.gridApi.showLoadingOverlay();
    this.http.get<ToDoViewModel[]>('api/ToDodata/GetAllToDoItems').subscribe(result => {
      this.rowData = result;
      //this.gridApi.hideOverlay();
    },
      error => {
        console.error(error);
        //this.gridApi.hideOverlay();
      });
  }

  onCellValueChanged(item) {
    item.data.newOrModified = "modified";
  }
}
