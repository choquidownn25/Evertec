import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import Swal from 'sweetalert2';
import { DeleteComponent } from './dialogs/delete/delete.component';
import { Producto } from '../producto/models/producto';
import { ProductoService } from '../producto/services/producto.service';
import { Persona } from './models/persona';
import { PersonaService } from './service/persona.service';
import { AgregarComponent } from './dialogs/agregar/agregar.component';
import { EditarComponent } from './dialogs/editar/editar.component';



@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit , AfterViewInit {

  displayedColumn = ['id', 'nombre', 'descripcion', 'precio', 'cantidad', 'imagen', 'actions'];
  displayedColumns = ['id', 'nombre', 'apellido', 'fechaNacimiento', 'foto', 'estadoCivil', 'tieneHermanod', 'actions'];
  public productos = new MatTableDataSource<Producto>()
  public personas = new MatTableDataSource<Persona>()
  @ViewChild(MatSort)
  sort!: MatSort;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  index!: number;
  id!: number;

  constructor(
    public dialog: MatDialog,
    public dataService: ProductoService,
    public dataServicePersona: PersonaService) {
  
  }
  ngAfterViewInit(): void {
    this.personas.sort = this.sort;
    this.personas.paginator = this.paginator;
  }
  ngOnInit(){
    
    //this.getAllProducto();
    this.getAllPersona();
  }
  public getAllPersona = () => {
    this.dataServicePersona.getData()
    .subscribe(res => {
      this.personas.data = res as Persona[];
    })
  }

  public doFilter = (event: Event) => {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLocaleLowerCase();
    this.personas.filter = filterValue;
  }
  addNew() {
    const dialogRef = this.dialog.open(AgregarComponent, {
      data: {persona:  Persona }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        // After dialog is closed we're doing frontend updates
        // For add we're just pushing a new row inside DataService
       // this.exampleDatabase.dataChange.value.push(this.dataService.getDialogData());
        //this.refreshTable();
        this.getAllPersona();
      }
      //this.getAllProducto();
    });
  }
  //displayedColumns = ['id', 'nombre', 'apellido', 'fechaNacimiento', 'foto', 'estadoCivil', 'tieneHermanod', 'actions'];
 
  startEdit(i: number, id: number, nombre: string, apellido: string, fechaNacimiento: Date, foto: string, estadoCivil: string, tieneHermanod: boolean) {
    this.id = id;
    // index row is used just for debugging proposes and can be removed
    this.index = i;
    //console.log(this.index);
    const dialogRef = this.dialog.open(EditarComponent, {
      data: {id: id, nombre: nombre, apellido: apellido, fechaNacimiento: fechaNacimiento, foto: foto, estadoCivil: estadoCivil, tieneHermanod: tieneHermanod}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        // When using an edit things are little different, firstly we find record inside DataService by id
        //const foundIndex = this.exampleDatabase.dataChange.value.findIndex(x => x.id === this.id);
        // Then you update that record using data from dialogData (values you enetered)
        //this.exampleDatabase.dataChange.value[foundIndex] = this.dataService.getDialogData();
        // And lastly refresh table
        //this.refreshTable();
        this.getAllPersona();
      }
    });
  }
  //deleteItem(i: number, id: number, nombre: string, descripcion: string, precio: number, cantidad: number, imagen: string) {
  deleteItem(i: number, id: number, nombre: string, apellido: string, fechaNacimiento: Date, foto: string, estadoCivil: string, tieneHermanod: boolean) {
    this.index = i;
    this.id = id;

    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: false
    })

    const dialogRef = this.dialog.open(DeleteComponent, {
      data: {id: id, nombre: nombre, apellido: apellido, fechaNacimiento: fechaNacimiento, foto: foto, estadoCivil: estadoCivil, tieneHermanod: tieneHermanod}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        //const foundIndex = this.exampleDatabase.dataChange.value.findIndex(x => x.id === this.id);
        // for delete we use splice in order to remove single object from DataService
        //this.exampleDatabase.dataChange.value.splice(foundIndex, 1);
        //this.refreshTable();
        this.getAllPersona();
      }
    });
    
  }
}
