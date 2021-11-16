import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { UserDetail } from 'src/app/shared/models/userDetail';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  userDetail !: UserDetail
  id!:number
  constructor(private activeRoute:ActivatedRoute,private userService:UserService) { }

  ngOnInit(): void {
    this.activeRoute.paramMap.subscribe(
      p=>{
        this.id = Number(p.get('id'))
      }
    )
    this.userService.getUserDetails(this.id).subscribe(
      u=>{
        this.userDetail=u
        console.log(this.userDetail)
      }
    )
  }

}
