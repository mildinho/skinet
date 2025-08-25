import { Component, inject, OnInit } from '@angular/core';
import { ProductItemComponent } from "./product-item/product-item.component";
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatSelectionList, MatListOption, MatSelectionListChange  } from '@angular/material/list';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../shared/models/pagination';
import { FormsModule } from '@angular/forms';
import { SalesParams } from '../../shared/models/salesParams';
import { SalesService } from '../../core/services/sales.service';
import { BuscaProduto } from '../../shared/models/buscaproduto';
import { SnackbarService } from '../../core/services/snackbar.service';
@Component({  
  selector: 'app-sales',
  standalone: true,
  imports: [ProductItemComponent, MatButton, MatIcon, MatMenu, MatSelectionList, 
    MatListOption, MatMenuTrigger, MatPaginator, FormsModule],
  templateUrl: './sales.component.html',
  styleUrl: './sales.component.scss'
})

export class SalesComponent implements OnInit {

  private salesService = inject(SalesService);
  private dialogService = inject(MatDialog);
  private snackBarService = inject(SnackbarService);
 
  products?      : Pagination<BuscaProduto>;

  sortOptions  =[
    {name: 'Alfabética', value: 'name'},
    {name: 'Menor Preço', value: 'priceAsc'},
    {name: 'Maior Preço', value: 'priceDesc'},
  ]

  shopParams = new SalesParams();
  
  pageSizeOptions = [5, 10, 15, 20];

  ngOnInit(): void {
      this.CarregaObjetos();
  }


  CarregaObjetos(){
    this.getProducts();
  }


  getProducts(){
    this.salesService.getProducts(this.shopParams).subscribe({
      next: (response) => {
        this.products = response
        
      },
      error: (error) => {
        this.snackBarService.info(error.error);
      } 
      
    })
  }


  onSearchChange(){
   
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }


  handlePageChange(event: PageEvent){
    this.shopParams.pageNumber = event.pageIndex + 1;
    this.shopParams.pageSize = event.pageSize;
    this.getProducts();
  }

  onSortChange(event: MatSelectionListChange){
   const selectedOption = event.options[0];

    if ( selectedOption ) {
      this.shopParams.sort = selectedOption.value;
      this.getProducts();
      this.shopParams.pageNumber = 1;
    }
  }

  openFiltersDialog(){
    const dialogRef = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedFabricantes: this.shopParams.idfabricantes,
      }

    });

    dialogRef.afterClosed().subscribe({
      next: (result) => {
        if(result){
          console.log(result);
          
          this.shopParams.idfabricantes = result.selectedFabricantes;
          this.shopParams.pageNumber = 1;


          this.getProducts();
        }
      }
    });

    
    
  }

}
