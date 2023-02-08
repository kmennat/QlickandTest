import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  siteLanguage = 'English';
  languageList = [
    { code: 'en', label: 'English' },
    { code: 'de', label: 'Deutsch' },
  ];

  selectedFlag = "america.png"

  constructor(private translate: TranslateService) { }

  ngOnInit(): void {
  }

  scrollToDiv(id:any) {    
    console.log(`scrolling to ${id}`);
    let el = document.getElementById(id);
    el?.scrollIntoView({behavior: 'smooth'});
  }

  toggleFlag(flagName:any){
    this.selectedFlag = flagName
  }

  changeSiteLanguage(event: any): void {
    const selectedLanguage = this.languageList
      .find((language) => language.code === event)
      ?.label.toString();
    if (selectedLanguage) {
      this.siteLanguage = selectedLanguage;
      this.translate.use(event);
    }
    const currentLanguage = this.translate.currentLang;
    console.log('currentLanguage', currentLanguage);
  }

}
