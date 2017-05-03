$(document).ready(function () {
    $('#ShowNewCharacterFormButton').on('click', function (event) {
        event.preventDefault();
        $('#CharacterDropdown').hide();
        $('#NewCharacterForm').show();
    });
    $('#NewCharacterCancelButton').on('click', function (event) {
        event.preventDefault();
        $('#CharacterDropdown').show();
        $('#NewCharacterForm').hide();
    });
    $('#NewCharacterOkButton').on('click', function (event) {
        event.preventDefault();
        

        $.post('/api/Charactersapi', {
            CharacterName: $('#NewCharacterName').val()
        }).done(function (data) {
            console.log(data);
            $('#CharacterID').append(new Option(data.CharacterName, data.CharacterID));
            $('#CharacterID').val(data.CharacterID);

            $('#NewCharacterName').val('');

            $('#CharacterDropdown').show();
            $('#NewCharacterForm').hide();
        });

    });
});