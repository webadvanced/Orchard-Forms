
function updateWeights() {
    var patt = new RegExp("Fields\\[[0-9]+\\].Weight");
    $(".manage-field").each(function (i, e) {
        $(e).find("input[name$=Weight]").val(i);
    });
}

function updateForm() {
  //  updateWeights();

    // Prefix each field
    $(".manage-field").each(function (i, e) {
        var prefix = $(e).find("input[name$=Name]").val();
        $(e).prepend('<input type="hidden" name="Fields.Index" value="' + prefix + '"/>');

        patt = new RegExp("Fields\\[[0-9]+\\]");
        $(e).find('[name^="Fields["]').each(function(fi, fe) {
            $(fe).attr("name", "Fields[" + prefix + "]" + $(fe).attr("name").replace(patt, ""));
        });


        $(e).prepend('<input type="hidden" name="Textboxes.Index" value="' + prefix + '"/>');

        patt = new RegExp("Textboxes\\[[0-9]+\\]");
        $(e).find('[name^="Textboxes["]').each(function (fi, fe) {
            $(fe).attr("name", "Textboxes[" + prefix + "]" + $(fe).attr("name").replace(patt, ""));
        });
    });
}

function initialize() {
    $(".manage-field").each(function (i, e) {
        $(".fields-container").append($(e));
    });
}

function isEmpty(value) {
    patt = new RegExp("/^\s*$");
    return (!value || patt.test(value));
}

function validateForm() {
    var names = [];
    var firstErrorElement = null;
    $("div.error").remove();
    $(".manage-field").each(function (i, e) {
        // Validate that Name exists
        var name = $(e).find('input[name$="].Name"]');
        name.removeClass("error");
        if (isEmpty(name.val())) {
            firstErrorElement = firstErrorElement != null ? firstErrorElement : $(this);
            name.addClass("error");
            name.after('<div class="error">Name is required</div>');
        } else {
            // Validate that the name isn't already used
            if (jQuery.inArray(name.val(), names) > -1) {
                firstErrorElement = firstErrorElement != null ? firstErrorElement : $(this);
                name.addClass("error");
                name.after('<div class="error">Duplicate field name</div>');
            } else {
                names.push(name.val());
            }
        }

        // Validate that label exists
        var label = $(e).find('input[name$="].Label"]');
        label.removeClass("error");
        if (isEmpty(label.val())) {
            firstErrorElement = firstErrorElement != null ? firstErrorElement : $(this);
            label.addClass("error");
            label.after('<div class="error">Label is required</div>');
        }
    });
    if (firstErrorElement != null) {
        // TODO: Open the field pane if it's closed
        $(window).scrollTo(firstErrorElement, 300);
    }
    return firstErrorElement;
}

function getUniqueFieldNumber() {
    var fNum = 0;
    while ($(".fields-container").find('[name^="Fields[' + fNum + '"]').length > 0 || $(".fields-container").find('[name^="Textboxes[' + fNum + '"]').length > 0)
        fNum++;
    return fNum;
}

$(document).ready(function () {
    $(".handler-list ul li a").click(function (e) {
        $.ajax({
            data: {
                handler: $(this).html()
            },
            type: "POST",
            url: $(this).attr("href"),
            success: function (data) {
                var o = $(data);
                var fNum = getUniqueFieldNumber();
                console.log(fNum);
                o.find('[name^="Fields["]').each(function (fi, fe) {
                    $(fe).attr("name", "Fields[" + fNum + "]" + $(fe).attr("name").replace("Fields[0]", ""));
                });
                o.find('[name^="Textboxes["]').each(function (fi, fe) {
                    $(fe).attr("name", "Textboxes[" + fNum + "]" + $(fe).attr("name").replace("Textboxes[0]", ""));
                });
                o.hide();
                $(".fields-container").append(o);
                o.fadeIn(600);
                $(window).scrollTo(o, 400);
            }
        });
        e.preventDefault();
    });

    $(".save-button button").click(function (event) {
        //    if (validateForm() == null) {
        updateForm();
        //  } else {
        //        event.preventDefault();
        //     }
    });

    // Remove Field Button
    $(".fields-container").delegate(".manage-field-header a.delete", "click", function (event) {
        $(this).closest(".manage-field").fadeOut(500, function () {
            $(this).remove();
        });
        event.preventDefault();
    });

    // Open / Close Detail pane
    $(".fields-container").delegate(".expando-glyph", "click", function () {
        var _this = $(this).parent();
        var panel = _this.closest(".manage-field-header").next();

        if (_this.hasClass("closed") || _this.hasClass("closing")) {
            panel.slideDown(300, function () { _this.removeClass("opening").removeClass("closed").addClass("open"); });
            _this.addClass("opening");
        }
        else {
            panel.slideUp(300, function () { _this.removeClass("closing").removeClass("open").addClass("closed"); });
            _this.addClass("closing");
        }
    });

    // Sortable functionality
    $(".fields-container").sortable({
        handle: ".manage-field-header",
        axis: 'y'
    });

    // Pin the tools window on scroll
    var toolsOffset = $(".field-tools").offset();
    var toolsDiv = $(".field-tools");

    $(window).scroll(function (e) {
        if ($(window).scrollTop() > toolsOffset.top - 15) {
            toolsDiv.addClass("sticky");
        } else {
            toolsDiv.removeClass("sticky");
        }
    });

    initialize();
});        
