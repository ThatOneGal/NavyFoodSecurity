@extends('pagetemplate')
@section('content')
        <div>
            @if ($errors->any())
                <div class="alert alert-danger">
                    <ul>
                        @foreach ($errors->all() as $error)
                            <li>{{ $error }}</li>
                        @endforeach
                    </ul>
                </div>
            @endif

            <form method="POST" action="{{ route('login') }}">
            @csrf
                <label for="service_number">Service Number</label>
                <input class="login" id="service_number" type="text" name="service_number" required>
                <label for="password">Password</label>
                <input class="login" id="password" type="password" name="password" required>
                <button class="button btn-alert" type="submit">Log-in</button>
            </form>
        </div>
@endsection
