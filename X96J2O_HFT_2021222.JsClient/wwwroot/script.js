let rents = [];
let cars = [];
let rentIdToUpdate = -1;
let connection=null;

getData();
setupSinalR();

function setupSinalR() {
     connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:35445/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build()
    connection.on("RentCreated", (user, message) => {
        getData();
    });
    connection.on("RentDeleted", (user, message) => {
        getData();
    });
    connection.on("RentUpdated", (user, message) => {
        getData();
    });
    
    connection.onclose(async () => {
            await start();
     });
    start();
}

async function getData() {
    await fetch('http://localhost:35445/Car')
        .then(x => x.json())
        .then(y => {
            cars = y;
          
        });
   await fetch('http://localhost:35445/Rent')
        .then(x => x.json())
        .then(y => {
            rents = y;
            display();
        });

};
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function display() {
    document.getElementById('resultarea').innerHTML += "";
    rents.forEach(t => {
        
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.rentId + "</td><td>"
            + t.firstName + "</td><td>" + t.lastName + "</td><td>"
            + t.phone + "</td><td>" + t.mail + "</td><td>" + t.car.model + "</td><td>"
        + t.out + "</td><td>" + t.in + "</td><td>" +
        ` <button type="button" onclick="remove(${t.rentId})"> Delete </button> ` +
        ` <button type="button" onclick="showupdate(${t.rentId})"> Update </button> ` +
        "</td></tr>"
        console.log(t.firstName);
    });
    cars.forEach(x => {
        document.getElementById('carselection').innerHTML +=
            "<option value=" + x.carId + ">" + x.model + "</option>"
        document.getElementById('carselectiontoupdate').innerHTML +=
            "<option value=" + x.carId + ">" + x.model + "</option>"
    });
}

function showupdate(id) {
    document.getElementById("firstnametoupdate").value = rents.find(t => t['rentId'] == id)['firstName'];
    document.getElementById("lastnametoupdate").value = rents.find(t => t['rentId'] == id)['lastName'];
    document.getElementById("phonetoupdate").value = rents.find(t => t['rentId'] == id)['phone'];
    document.getElementById("mailtoupdate").value = rents.find(t => t['rentId'] == id)['mail'];
    document.getElementById("outtoupdate").value = rents.find(t => t['rentId'] == id)['out'];
    document.getElementById("intoupdate").value = rents.find(t => t['rentId'] == id)['out'];
    document.getElementById("carselectiontoupdate").value = rents.find(t => t['rentId'] == id)['carId'];
    document.getElementById("updateformdiv").style.display = 'flex';
    rentIdToUpdate = id;
}


function remove(id) {
    fetch('http://localhost:35445/Rent/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
         
        });

}
function create() {
    let firstName = document.getElementById('firstname').value;
    let lastName = document.getElementById('lastname').value;
    let phone = document.getElementById('phone').value;
    let mail = document.getElementById('mail').value;
    let carId = document.getElementById('carselection').value;
    let ki = document.getElementById('out').value;
    let be = document.getElementById('in').value;
   

    fetch('http://localhost:35445/Rent', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                firstName: firstName,
                lastName: lastName,
                phone: phone,
                mail: mail,
                carId: carId,
                out: ki,
                in:be
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);

        });

}
function update() {
    document.getElementById("updateformdiv").style.display = 'none';
    let firstName = document.getElementById('firstnametoupdate').value;
    let lastName = document.getElementById('lastnametoupdate').value;
    let phone = document.getElementById('phonetoupdate').value;
    let mail = document.getElementById('mailtoupdate').value;
    let carId = document.getElementById('carselectiontoupdate').value;
    let ki = document.getElementById('outtoupdate').value;
    let be = document.getElementById('intoupdate').value;


    fetch('http://localhost:35445/Rent', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentId: rentIdToUpdate,
                firstName: firstName,
                lastName: lastName,
                phone: phone,
                mail: mail,
                carId: carId,
                out: ki,
                in: be
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}