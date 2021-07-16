<!DOCTYPE html>
<html lang="en">
<head>
    <title>Naval Meal Requisitions</title>
    <meta charset="UTF-8">
    <meta name="author" content="NavyFoodAppTeam">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/foundation-sites@6.6.3/dist/css/foundation.min.css"
          integrity="sha256-ogmFxjqiTMnZhxCqVmcqTvjfe1Y/ec4WaRj/aQPvn+I="
          crossorigin="anonymous">
    <link rel="stylesheet" type="css/text" href="{{URL::asset('css/app.css')}}"/>

    <!-- Link to activate motion-ui -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/motion-ui@1.2.3/dist/motion-ui.min.css"/>

</head>
<body>

<!-- Open page div -->
<div class="grid-background full grid-x">

    <!-- Page content -->
    @yield('content')

    <!-- Close page div -->
</div>

@auth
    <!-- Log-out -->
<form style="margin-left:5%" method="POST" action="{{route('logout')}}">
    @csrf
    <button class="button button-primary" type="submit">LOG-OUT</button>
</form>
@endauth

<script src="https://code.jquery.com/jquery-3.6.0.min.js"
        integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
        crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/foundation-sites@6.6.3/dist/js/foundation.min.js"
        integrity="sha256-pRF3zifJRA9jXGv++b06qwtSqX1byFQOLjqa2PTEb2o=" crossorigin="anonymous"></script>

<script>
    $(document).foundation();
</script>
</body>
</html>
