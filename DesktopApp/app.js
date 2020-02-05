
function getStudentsList() {
    const container = document.getElementById("container");

    var request = new XMLHttpRequest();//JSONHttpRequest
    request.open('GET', 'http://localhost:50731/api/people/RequsetAll', true);
    request.responseType = 'json';
    //request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
   // request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    
    request.onload = function (res) {

        var data = JSON.parse(this.response);
        if (request.status >= 200 && request.status < 400) {
            data.forEach(student => {
                const stu = document.createElement('div');
                stu.setAttribute('class', 'stu');

                const p = document.createElement('p');
                p.textContent = student.first_name;

                container.appendChild(stu);
                stu.appendChild(p);
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