@extends('pagetemplate')
@section('content')
    <br/>
    <h3 class="heading"><strong>Register Staff Member</strong></h3>
    <br/>
    <div class="cell">
        <form style="margin-left:5%" method="POST" action="{{route('admin.edit')}}">
            @csrf
            <label>Enter Name:</label>
            <input type="text" id="service_number" name="service_number" style="width: 10%"
                   value="{{old('service_number')}}">
            <input type="text" id="rank" name="rank" style="width: 10%"
                   value="{{old('rank')}}">
            <input type="text" id="first_name" name="first_name" style="width: 15%"
                   value="{{old('first_name')}}">
            <input type="text" id="last_name" name="last_name" style="width: 15%"
                   value="{{old('last_name')}}">
            <input type="number" id="admin" name="admin" style="width: 10%"
                   value="{{old('admin')}}">
            <input type="password" id="password" name="password" style="width: 20%"
                   value="{{old('password')}}">
            <br>
            <table style="width: 15%;">
                <tr>
                    <td>
                        <button class="button button-primary" type="submit">UPDATE</button>
                    </td>
                    <td>
                        <button><a href="{{ URL::previous() }}" class="button button-primary">EXIT</a></button>
                    </td>
                </tr>
            </table>
        </form>
    </div>
@endsection
