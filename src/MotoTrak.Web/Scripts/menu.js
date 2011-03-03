function initializeMenu(menuId) {
  var elementName = "#" + menuId + " li";

  $(elementName).click(
    function () {
      $(this).find("ul").slideDown("fast");

      $(this).mouseleave(
        function () {
          $(this).find("ul").slideUp("medium");
        }
      );
    }
  );

  $(elementName).hover(
    function () {
      $(this).addClass("sfhover");
    },
    function () {
      $(this).removeClass("sfhover");
    }
  );
}