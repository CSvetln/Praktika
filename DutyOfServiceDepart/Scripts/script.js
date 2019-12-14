function funcEdit(id) {
    var divsToHide = document.getElementsByClassName("pencil");
    for (var i = 0; i < divsToHide.length; i++) {
        divsToHide[i].style.visibility = "hidden";
    }
    document.getElementById(id).className = "block";
    return false;
}
