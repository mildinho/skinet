import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../core/services/shop.service';
import { ProductItemComponent } from "./product-item/product-item.component";
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatSelectionList, MatListOption, MatSelectionListChange  } from '@angular/material/list';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { ShopParams } from '../../shared/models/shopParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../shared/models/pagination';
import { FormsModule } from '@angular/forms';
@Component({  
  selector: 'app-shop',
  standalone: true,
  imports: [ProductItemComponent, MatButton, MatIcon, MatMenu, MatSelectionList, 
    MatListOption, MatMenuTrigger, MatPaginator, FormsModule],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})

export class ShopComponent implements OnInit {

  private shopService = inject(ShopService);
  private dialogService = inject(MatDialog);
 
  products?      : Pagination<Product>;

  sortOptions  =[
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
  ]

  shopParams = new ShopParams();
  pageSizeOptions = [5, 10, 15, 20];

  ngOnInit(): void {
      this.initializeBrands();
  }


  initializeBrands(){
    this.shopService.getBrandes();
    this.shopService.getTypes();

    this.getProducts();
  }

  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response) => this.products = response,
      error: (error) => console.log(error),
      
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
        selectedBrand: this.shopParams.brands,
        selectedType: this.shopParams.types
      }

    });

    dialogRef.afterClosed().subscribe({
      next: (result) => {
        if(result){
          console.log(result);
          
          this.shopParams.brands = result.selectedBrand;
          this.shopParams.types = result.selectedType;
          this.shopParams.pageNumber = 1;


          this.getProducts();
        }
      }
    });

    
    
  }

}
