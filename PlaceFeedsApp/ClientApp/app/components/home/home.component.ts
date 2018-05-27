import { Component } from '@angular/core';

import { TransferService } from '../../services/shared/transfer/transfer.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    providers: [TransferService]
})
export class HomeComponent {

}
