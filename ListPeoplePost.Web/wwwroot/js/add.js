$(() => {
    let num = 1;

    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row person-row" style='margin-bottom:10px;'>
                <div class="col-md-3">
                    <input class="form-control first-name" type="text" name="people[${num}].firstname" placeholder="First Name"/>
                </div>
                <div class="col-md-3">
                    <input class="form-control last-name" type="text" name="people[${num}].lastname" placeholder="Last Name"/>
                </div>
                <div class="col-md-3">
                    <input class="form-control age" type="text" name="people[${num}].age" placeholder="Age"/>
                </div>
                <div class="col-md-3">
                        <button type="button" class="btn btn-danger delete">Delete</button>
                    </div>
            </div> `);
        num++;
    });

    //$("#add-rows").on('click', function () {
    //    $("#ppl-rows").append(`<div class="row person-row" style='margin-bottom:10px;'>
    //            <div class="col-md-3">
    //                <input class="form-control first-name" type="text" placeholder="First Name"/>
    //            </div>
    //            <div class="col-md-3">
    //                <input class="form-control last-name" type="text" placeholder="Last Name"/>
    //            </div>
    //            <div class="col-md-3">
    //                <input class="form-control age" type="text" placeholder="Age"/>
    //            </div>
    //            <div class="col-md-3">
    //                    <button type="button" class="btn btn-danger delete">Delete</button>
    //                </div>
    //        </div> `);
    //    num++;
    //});

    //$("form").on('submit', function () {
    //    let index = 0;
    //    $(".person-row").each(function () {
    //        const row = $(this);
    //        row.find('.first-name').attr('name', `people[${index}].firstname`);
    //        row.find('.last-name').attr('name', `people[${index}].lastname`);
    //        row.find('.age').attr('name', `people[${index}].age`);
    //        index++;
    //    });
    //});

    function recalculateIndices() {
        let index = 0;
        $(".person-row").each(function () {
            const row = $(this);
            //row.find('.first-name').attr('name', `people[${index}].firstname`);
            //row.find('.last-name').attr('name', `people[${index}].lastname`);
            //row.find('.age').attr('name', `people[${index}].age`);
            const inputs = row.find("input");
            inputs.each(function () {
                const input = $(this);
                const name = input.attr('name'); 
                const indexOfDot = name.indexOf('.');
                const attrName = name.substring(indexOfDot + 1);
                input.attr('name', `people[${index}].${attrName}`);
            });
            index++;
        });
    }

    $("#ppl-rows").on('click', '.delete', function () {
        const button = $(this);
        const row = button.closest('.person-row');
        row.slideUp(400, function () {
            row.remove();
            recalculateIndices();
        });
    })
});