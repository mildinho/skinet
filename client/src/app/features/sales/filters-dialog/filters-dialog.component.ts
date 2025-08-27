import { Component, inject, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SalesService } from '../../../core/services/sales.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FabricanteParams } from '../../../shared/models/fabricanteParams';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Fabricante } from '../../../shared/models/fabricante';
import { Pagination } from '../../../shared/models/pagination';
@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [MatDivider, MatButton, MatIcon, FormsModule, MatFormFieldModule, MatSelectModule, FormsModule, ReactiveFormsModule],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent implements OnInit {

  private salesService = inject(SalesService);
  private snackBarService = inject(SnackbarService);
  

  private dialogRef = inject(MatDialogRef<FiltersDialogComponent>);
  data = inject(MAT_DIALOG_DATA);

  selectedFabricantes: string[] = this.data.selectedFabricantes;

  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];

  fabricanteParams = new FabricanteParams();
  listaFabricantes? : Pagination<Fabricante>;




  ngOnInit(): void {
    this.CarregaObjetos();
  }


  CarregaObjetos() {

    this.getFabricantes();
  }


  getFabricantes(){
    this.salesService.getFabricantes(this.fabricanteParams).subscribe({
      next: (response) => {
        this.listaFabricantes = response
        
      },
      error: (error) => {
        this.snackBarService.info(error.error);
      } 
      
    })
  }

  applyFilters() {
    this.dialogRef.close({
      selectedFabricantes: this.selectedFabricantes,
    });
  }
}
