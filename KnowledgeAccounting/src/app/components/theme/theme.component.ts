import { Theme } from './../../interfaces/theme';
import { ThemeService } from '../../services/theme/theme.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
  styleUrls: ['./theme.component.css']
})
export class ThemeComponent implements OnInit {

  constructor(private themeService: ThemeService) { }

  themes: Theme[] = [];

  ngOnInit(): void {
    this.themeService.getThemes().subscribe((data) => {
      this.themes = data;
    });
  }

}
