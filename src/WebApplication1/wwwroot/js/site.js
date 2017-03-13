function EscapeQuotesAndSlashes(string) {
    return (string + '').replace(/[\\"']/g, '\\$&').replace(/\u0000/g, '\\0');
}

function SendRequest(uri, data, callback) {
    var httpRequest = new XMLHttpRequest();
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            callback(httpRequest.responseText);
        }
    }
    var dataWithEscapedCharacters = EscapeQuotesAndSlashes(data);
    httpRequest.open("POST", uri, true);
    httpRequest.setRequestHeader("Content-Type", "application/json");
    httpRequest.send("\"" + dataWithEscapedCharacters + "\"");
}

function DisplayResult(text) {
    document.getElementById("resultTextArea").innerText = text;
}

function ConvertToXml() {
    var input = document.getElementById("input").value;
    SendRequest("/api/toXml", input, DisplayResult);
}

function ConvertToCsv() {
    var input = document.getElementById("input").value;
    SendRequest("/api/toCsv", input, DisplayResult);
}