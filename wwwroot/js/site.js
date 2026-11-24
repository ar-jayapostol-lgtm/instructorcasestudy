$(document).ready(function () {
    // Validation para sa Login at Register forms
    $("form").on("submit", function (e) {
        let isValid = true;

        // Suriin ang bawat input at select fields sa form
        $(this).find("input, select").each(function () {
            // Huwag pansinin ang mga hidden inputs o submit buttons
            if ($(this).attr("type") !== "hidden" && $(this).attr("type") !== "submit") {
                if ($.trim($(this).val()) === "") {
                    isValid = false;
                    $(this).css("border-color", "red"); // Maglalagay ng pulang border sa blangko
                } else {
                    $(this).css("border-color", ""); // Tanggalin ang pulang border kapag may laman na
                }
            }
        });

        if (!isValid) {
            e.preventDefault(); // Pipigilan ang pag-submit ng form
            alert("Mangyaring punan ang lahat ng kinakailangang field bago magpatuloy.");
        }
    });
});