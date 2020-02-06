
function getUsers() {
    const tblContainer = document.getElementById("tbl_container");

    var request = new XMLHttpRequest();//JSONHttpRequest
    request.open('GET', 'http://localhost:50731/api/Users/getUsers', true); //WEB API C#
    //request.open('GET', 'http://localhost:3000/getUsers', true); //WEB API NodeJS

    request.responseType = 'json';
    //request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
   // request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    //request.setRequestHeader('Access-Control-Allow-Origin', '*');
    var arrOfUsersFileds = ["first_name", "last_name", "email"]
    request.onload = function () {

        var data = JSON.parse(this.response);
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
            const errorMessage = document.createElement('marquee');
            errorMessage.textContent = `Gah, it's not working!`;
            app.appendChild(errorMessage);
        }
    }

    request.send();
}