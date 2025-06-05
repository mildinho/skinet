import { Component, inject } from '@angular/core';
import { ShopService } from '../../../core/services/shop.service';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatListOption, MatSelectionList } from '@angular/material/list';
import { MatDivider } from '@angular/material/divider';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [MatSelectionList, MatDivider, MatListOption, MatButton, MatIcon, FormsModule],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {

    shopService = inject(ShopService);

    private dialogRef = inject(MatDialogRef<FiltersDialogComponent>);
    data = inject(MAT_DIALOG_DATA);

    selectedBrand: string[] = this.data.selectedBrand;
    selectedType: string[] = this.data.selectedType;
  

    applyFilters(){
      this.dialogRef.close({
        selectedBrand: this.selectedBrand,
        selectedType: this.selectedType
      });
    }
}
