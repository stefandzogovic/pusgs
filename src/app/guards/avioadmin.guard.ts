import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AvioadminGuard implements CanActivate {
  constructor(private data: UserService)
  {

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    console.log('does something');
    const user = this.data.UserFromStorage();
    console.log(user);
    if (user.type === 'adminavio' || user.type === 'admin') {
      return true;
    }
      
    alert('Da biste pristupili ovom linku, morate imati ulogu korisnika!');
    return ;
  }
  
}
