document.getElementById("sendForm").addEventListener("click", function () {

    var url = "https://localhost:5003/api/send_emails";

    fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET, POST, PUT',
            'Access-Control-Allow-Headers': 'Content-Type'
        },
        body: JSON.stringify({
            companyName: document.getElementById("PNO").value,
            reportName: document.getElementById("ND").value,
            reporterName: document.getElementById("FullNameReporter").value,
            section: document.getElementById("Section").value,
            address: document.getElementById("Address").value,
            phoneNumber: document.getElementById("Phone").value,
            email: document.getElementById("E-mail").value,
            leadName: document.getElementById("FullNameDirector").value,
            neededSendEmail: document.getElementById("NeedSendEmail").checked,
            neededHostel: document.getElementById("NeedHostel").checked
        })
            
    });
});