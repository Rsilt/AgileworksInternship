document
  .getElementById("complaintForm")
  .addEventListener("submit", function (event) {
    event.preventDefault();

    document.getElementById("message").style.display = "block";

    document.getElementById("complaint").value = "";
  });
