$(document).ready(function () {
    $(".project-selector-ajax").select2({
        ajax: {
            url: "../../../Projects/GetJson",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return { s: params.term, page: params.page };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;
                return {
                    results: data,
                    pagination: {
                        more: (params.page * 30) < data.length
                    }
                };
            },
            cache: true
        },
        placeholder: 'Write name of Project for search',
        minimumInputLength: 1,
        tags: true,
        selectOnClose: true,
        createTag: function (tag) {
            return { id: tag.term, text: tag.term, isNew: true };
        }
    }).on('select2:select', function (evt) {
        if (evt.params.data.isNew == true) {
            if (confirm("Are you sure to create a new Project?")) {
                var select2Element = $(this);
                $.post("../../../Projects/CreateFromJson", { name: evt.params.data.text }, function (data) {
                    $('.project-selector-ajax option')
                        .removeAttr('selected')
                        .filter('[value=' + data.name + ']')
                        .val(data.projectId)
                        .attr('selected', true);
                    $(".project-selector-ajax").val(data.projectId).change();
                }, 'json');
            } else {
                $(this).val(null).trigger('change');
            }
        }
    });
});