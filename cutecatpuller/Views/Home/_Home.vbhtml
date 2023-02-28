<!-- ko with: home -->
<div class="jumbotron">
    <h1>Cute Cat Puller</h1>
    <p class="lead">A little project I started 2/22/2023 to prepare for my conversation with the folks at StafferLink</p>
    <p class="lead">This is a simple little MVC app to load 'Cute Cats' from  <a href="http://cataas.com">http://cataas.com</a></p>
    <p class="lead">I wanted to challenge myself in VB.net and also show some basic coding principles here.  
        S.O.L.I.D programming techniques for seperation of concern, abstraction and inheritance are at play in the backend and a bit of SPA / ajax with axios on the front end.
    </p>
</div>
<script type="text/javascript">
    function getCuteCats() {
        axios.get('/home/getCuteCats').then(response => {
            $("#grid").jqGrid({
                colModel: [
                    { name: "owner" },
                    { name: "tags" },
                    {
                        name: "imageUrl", width: 100, formatter: function (item)
                        {
                            return `<img src='${item}' style='max-height:100px; max-width:100px'/>`
                        }
                    },
                ],
                data: response.data
            });
        })
    }

</script>
<div class="row">
    @Html.AntiForgeryToken()
    <text>
        <h4>Let's see some cute cats!</h4>
        <div class="form-group">
            <input class="btn btn-default" onclick="getCuteCats()" value="Load Cute Cats &raquo" /><i class="fa-solid fa-cat"></i>
        </div>
    </text>
    <div>
        <table id="grid">

        </table>
    </div>
</div>
<!-- /ko -->
