
function getUsers() {
    const tblContainer = document.getElementById("tbl_container");

    var request = new XMLHttpRequest();//JSONHttpRequest
    request.open('GET', 'http://localhost:50731/api/Users/getUsers', true);
    request.responseType = 'json';
    //request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
   // request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    var arrOfUsersFileds = ["first_name", "last_name", "email", "country"]
    request.onload = function () {

        var data = JSON.parse(this.response);
        if (data && request.status >= 200 && request.status < 400) {
            data.forEach(usr => {
                const tr = document.createElement('tr');
                tr.setAttribute('class', 'userTr');
                tblContainer.appendChild(tr);

                var td;
                var text;

                arrOfUsersFileds.forEach(key => {
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