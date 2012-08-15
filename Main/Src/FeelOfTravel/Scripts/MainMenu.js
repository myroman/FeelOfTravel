/* File Created: мая 20, 2012 */
function showSubMenu() {

  if ($(this).hasClass('showing-sub-menu')) {
    if ($(this).children('ul').hasClass('main-menu__second-level')) {
      $(this).find('.main-menu__second-level').css('display', 'block');
      return;
    } else if ($(this).children('ul').hasClass('main-menu__third-level')) {
      var menu = $(this).find('.main-menu__third-level');
      menu.css('display', 'block');
      var parentElem = $(this);
      var top = $(this).position().top + 'px';
      var left = parentElem.width() + 'px';
      menu.css('top', top);
      menu.css('left', left);

      return;
    }
  }
}

function hideSubMenu() {
  if ($('ul', this).hasClass('main-menu__second-level')) {
    $('.main-menu__second-level', this).css('display', 'none');
    $('.main-menu__third-level', this).css('display', 'none');
  }

  if ($('ul', this).hasClass('main-menu__third-level')) {
    $('.main-menu__third-level', this).css('display', 'none');
  }
}

