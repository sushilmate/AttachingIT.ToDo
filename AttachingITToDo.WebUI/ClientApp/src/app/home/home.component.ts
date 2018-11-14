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
  private gridColumnApi;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
  }

  ngOnInit() {
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
    var selectedData = this.gridApi.getSelectedRows();
    this.gridApi.updateRowData({ remove: selectedData });
    var filteredData = selectedData.filter(x => x.id != 0);
    this.http.post(this.baseUrl + 'api/ToDodata/RemoveToDo', filteredData, httpOptions).subscribe(result => {
      alert("Selected Record(s) deleted successfully.");
    },
      error => console.log('There was an error: '));
  }

  onGridReady(params) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
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
    this.http.post<ToDoViewModel[]>(this.baseUrl + 'api/ToDodata/UpdateOrAddToDo', newOrModifiedToDos, httpOptions).subscribe(result => {
      this.rowData = result;
    },
      error => console.log('There was an error: '));
  }
  GetAllToDos() {
    this.http.get<ToDoViewModel[]>('api/ToDodata/GetAllToDoItems').subscribe(result => {
      this.rowData = result;
    },
      error => console.error(error));
  }
  onCellValueChanged(item) {
    item.data.newOrModified = "modified";
  }
}
