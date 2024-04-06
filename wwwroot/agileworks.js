document.addEventListener("DOMContentLoaded", function () {
  document
    .querySelector('input[type="submit"]')
    .addEventListener("click", function (event) {
      event.preventDefault();
      var clickCount = parseInt(localStorage.getItem("buttonClickCount")) || 0;
      clickCount++;
      localStorage.setItem("buttonClickCount", clickCount);
      var lastButtonClickTimestamp = new Date().toISOString();
      localStorage.setItem(
        "lastButtonClickTimestamp",
        lastButtonClickTimestamp
      );
      console.log(
        "Button click time:",
        localStorage.getItem("lastButtonClickTimestamp")
      );

      const complaintType = document.getElementById("complaint_type").value;
      const complaintText = document.getElementById("complaint").value;
      console.log("Complaint Type:", complaintType);
      console.log("Complaint:", complaintText);

      postAppealData(complaintType, complaintText);
    });
});

function postAppealData(complaintType, complaintText) {
  const url = "http://localhost:5042/api/test";
  const requestBody = {
    complaintType,
    complaintText,
  };

  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(requestBody),
  };

  fetch(url, options)
    .then((response) => response.json())
    .then((data) => console.log(data))
    .catch((error) => console.error(error));
}
