
function getUsers() {
    const tblContainer = document.getElementById("tbl_container");

    var request = new XMLHttpRequest();//JSONHttpRequest
    request.open('GET', 'http://localhost:50731/api/Users/getUsersFromDB', true); //WEB API C# with mongo DB
    //request.open('GET', 'http://localhost:3000/getUsers', true); //WEB API NodeJS

    request.responseType = 'json';
    var arrOfUsersFileds = ["first_name", "last_name", "email", "status"]
    request.onload = function () {

        var data = this.response;
        if (data && request.status >= 200 && request.status < 400) {
            data.map(usr => {
                const tr = document.createElement('tr');
                tr.setAttribute('class', 'userTr');
                tblContainer.appendChild(tr);

                var td;
                var text;

                arrOfUsersFileds.map((key, index) => {
                    td = document.createElement('td');
                    text = usr[key];
                    td.innerText = text;
                    tr.appendChild(td);
                });

            });
        } else {
            //handel error:
            //const errorMessage = document.createElement('marquee');
            //errorMessage.textContent = `Gah, it's not working!`;
            //app.appendChild(errorMessage);
        }
    }

    request.send();
}

function addUser() {
    let usr = {
        first_name: "some first name",
        last_name: "some last name",
        email: "email@gmail.com",
        status: "admin"
    };
    var params = JSON.stringify(usr);
    //const tblContainer = document.getElementById("tbl_container");

    var http = new XMLHttpRequest();//JSONHttpRequest
    http.open('POST', "http://localhost:50731/api/Users/AddUserToDB", true); //WEB API C# with mongo DB

    http.setRequestHeader("Content-Type", "application/json");//;charset=UTF-8
    http.setRequestHeader("Access-Control-Allow-Origin", "*");
    //http.setRequestHeader("Access-Control-Allow-Credentials", "true");
    //http.setRequestHeader("Access-Control-Allow-Methods", "DELETE, POST, GET, OPTIONS");
    //http.setRequestHeader("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

    http.responseType = 'json';
    http.onreadystatechange  = function () {

        var data = this.response;
        if (data && http.readyState == 4 && http.status == 200) {
            getUsers();
           
        } else {
            //handel error:
            //const errorMessage = document.createElement('marquee');
            //errorMessage.textContent = `Gah, it's not working!`;
            //app.appendChild(errorMessage);
        }
    }
    
    http.send(params);
}

function addUserWithAJAX() {
    let usr = {
        first_name: "some first name",
        last_name: "some last name",
        email: "email@gmail.com",
        status: ["admin"]
    };
    //$.ajax({
    //    data: JSON.stringify(usr),
    //    url: 'http://localhost:50731/api/Users/AddUserToDB',
    //    contentType: "application/json", method: "POST", processData: false
    //})
    //    .success(function (result) {
    //        console.log(111);
    //    });
}