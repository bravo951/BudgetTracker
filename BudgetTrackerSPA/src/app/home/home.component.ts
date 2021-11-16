import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { UserItem } from '../shared/models/userItem';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  users!:UserItem[];
  title = 'Budget Tracker UserList'
  constructor(private userService:UserService) { }
  
  ngOnInit(): void {
    this.userService.getUserList().subscribe(
      u => {
        this.users = u
        console.log(this.users)
      }
      
    )
  }

}
