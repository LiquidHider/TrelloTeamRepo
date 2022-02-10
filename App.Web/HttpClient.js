document.getElementById("sendForm").addEventListener("click", function() {
    var client = new XMLHttpRequest();

    var url = "localhost:44390/api/send_emails";
    
    client.open("POST",url,true);
    
    client.setRequestHeader("Content-Type","application/json");
    
    var data = JSON.stringify({
        companyName: document.getElementById("PNO").value,
        reportName: document.getElementById("ND").value,
        reporterName: document.getElementById("FullNameReporter").value,
        section: document.getElementById("Section").value,
        address: document.getElementById("Address").value,
        phoneNumber: document.getElementById("Phone").value,
        email: document.getElementById("E-mail").value,
        leadName: document.getElementById("FullNameDirector").value,
        neededSendEmail: document.getElementById("NeedSendEmail").checked,
        neededHostel: document.getElementById("NeedHostel").checked,
    });
    //client.send(data);
    console.log(data);
    console.log("data was sent");

});
