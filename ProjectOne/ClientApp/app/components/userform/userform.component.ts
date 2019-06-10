import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from "@angular/forms";
import 'rxjs/add/operator/debounceTime'
import { Http, Headers, RequestOptions } from '@angular/http';


function passwordMatcher(c: AbstractControl): { [key: string]: boolean } | null {
    let passwordControl = c.get('password');
    let confirmPasswordControl = c.get('cPassword');
    if (!passwordControl || !confirmPasswordControl)
        return null;

    if (passwordControl.pristine || confirmPasswordControl.pristine)
        return null;
    if (passwordControl.value === confirmPasswordControl.value)
        return null;
    return { 'matchPasswords': true };
}

function phoneRequired(c: AbstractControl): { [key: string]: boolean } | null {
    let verification = c.get("verification");
    let phone = c.get("phone");
    if (verification && verification.value == "sms" && (!phone || !phone.value.length)) {
        return null;
    }
    return {
        valid: false
    }

}
function TokenRequired(c: AbstractControl): { [key: string]: boolean } | null {
    //let verification = c.get("verification");
    //let token = c.get("Token");
    if (c.value == "abc123" && c.value.length) {
        return null;
    }
    return {
        valid: false
    }

}



@Component({
    selector: 'userform',
    templateUrl: './userform.component.html',
    styleUrls: ['./userform.component.css']
})
export class UserFormComponent implements OnInit {
    passwordMessages = {
        matchPasswords: "Passwords don't match", pattern: "Password is invalid"
    };
    matchPasswordsMsg: string = '';
    passwordPatternMsg: string = '';
    userForm: FormGroup;
    userExists: boolean = false;
    baseUrl: string = "";
    http: Http;
    constructor(private formBuilder: FormBuilder, http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.http = http;
    }

    ngOnInit() {

        this.userForm = this.formBuilder.group({
            firstName: ['', [Validators.required, Validators.minLength(3)]],
            lastName: ['', [Validators.required, Validators.maxLength(50)]],
            email: ['', [Validators.required, Validators.email]],
            //username: ['', [Validators.required, Validators.minLength(3)]],
            Token: ['', [TokenRequired]],
            phoneGroup: this.formBuilder.group({
                verification: [''],
                phone: ['', [Validators.pattern("[\+]\d{2}[\(]\d{2}[\)]\d{4}[\-]\d{4}")]],

            }, { validator: phoneRequired }),

            pswdGroup: this.formBuilder.group({
                password: ['', [Validators.required]],
                cPassword: ['', [Validators.required]]

            }, { validator: passwordMatcher })

        });

        //let userName = this.userForm.get('username');
        //if (userName) {
        //    userName.valueChanges.debounceTime(1000).subscribe(value => {
        //        if (value === 'admin')
        //            this.userExists = true;
        //        else this.userExists = false;
        //    });
        //}
        let passwordGroup = this.userForm.get("pswdGroup");
        let password = this.userForm.get("pswdGroup.password");

        if (password) {
            password.valueChanges.debounceTime(500).subscribe(value => {
                this.passwordPatternMsg = '';
                if (password && (password.touched || password.dirty) && passwordGroup && passwordGroup.getError('matchPasswords')) {
                    this.matchPasswordsMsg = this.passwordMessages['matchPasswords'];
                }
            });
        }
        let confirmPassword = this.userForm.get("pswdGroup.cPassword");
        if (confirmPassword) {
            confirmPassword.valueChanges.debounceTime(500).subscribe(value => {
                this.matchPasswordsMsg = '';
                if (confirmPassword && (confirmPassword.touched || confirmPassword.dirty) && passwordGroup && passwordGroup.getError('matchPasswords')) {
                    this.matchPasswordsMsg = this.passwordMessages['matchPasswords'];
                }
            });
        }
    }

    sendToAzure() {
        //if (!this.userForm.get("firstName") || !this.userForm.get("lastName") || !this.userForm.get("email") || !this.userForm.get("phoneNumber"))
            //return;
        var test = {
            "FirstName": "Mieszko",
            "LastName": "Pierwszy",
            "Email": "123@123.PL",
            "PhoneNumber": "555 666 777"
        }   
        let data = JSON.stringify(test);
        //let headers = new HttpHeaders();
        //headers.set('Content-Type', 'application/json');
        let headers = new Headers({ 'Content-Type': 'application/json' });

        //var body = "firstname=" + this.userForm.get("firstName").value + "&lastname=" + this.userForm.get("lastName").value + "&email=" + this.userForm.get("email").value + "&phoneNumber=" + this.userForm.get("phoneNumber").value;
        var body = "firstname=abc&lastname=zhp&email=qqq@wp.pl&phonenumber=123";
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.baseUrl + 'api/Azure/TriggerLogicApp', data, options).subscribe(data => { console.log(data) });
    }
}
