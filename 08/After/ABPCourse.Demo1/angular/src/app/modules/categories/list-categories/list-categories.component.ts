import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryDto } from '@proxy/categories';
import { CategoriesService } from '@proxy/categories/categories.service';

@Component({
  selector: 'app-list-categories',
  standalone: true,
  imports: [],
  templateUrl: './list-categories.component.html',
  styleUrl: './list-categories.component.scss'
})
export class ListCategoriesComponent implements OnInit {
  categories: CategoryDto[] = [];
  input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0 };

  constructor(private categoriesService: CategoriesService) {
  }
  ngOnInit(): void {
    this.categoriesService.getList(this.input).subscribe(result => this.categories = result.items);
  }
}
