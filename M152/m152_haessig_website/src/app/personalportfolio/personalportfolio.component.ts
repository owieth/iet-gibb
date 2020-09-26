import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-personalportfolio',
    templateUrl: './personalportfolio.component.html',
    styleUrls: ['./personalportfolio.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class PersonalportfolioComponent implements OnInit {

    userImages: any = [];

    constructor(private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.route.data.subscribe(value => {
            this.userImages = value.images;
        });


        //this.initCollection();
    }

    /*
        initCollection() {
            this.userImages.forEach(() => {
                new BeerSlider(document.getElementById('beer-slider'));
            });
        }

        openFullscreenDialog(path: string, filename: string, hasOriginal: boolean): void {
            const dialogRef = this.dialog.open(FullscreenDialogComponent, {
                height: 'fit-content',
                width: 'fit-content',
                data: {path, filename, hasOriginal}
            });
        }

        initCollection($event?: MatTabChangeEvent) {
            this.collections[$event === undefined ? this.tabGroup.selectedIndex : $event.index].pictures.forEach(p => {
                new BeerSlider(document.getElementById(p.filename + '-slider'));
            });
        }

        onLoad(picture: Picture, type: boolean) {
            if (type) {
                this.loadedInnerImages.add(picture);
            } else {
                this.loadedOuterImages.add(picture);
            }
        }*/
}
