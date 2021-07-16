@extends('pagetemplate)
@section('content')
    <br/>
    <h3 class="heading"><strong>De-List Staff Member</strong></h3>
    <br/>
    <div class="cell">
        <form style="margin-left:5%" method="POST" action="{{route('admin.destroy', $user)}}">
            @method('DELETE')
            @csrf
            <label>Confirm Delete:</label>
            <table style="width: 15%;">
                <tr>
                    <td>{{$user->service_number}}</td>
                    <td>{{$user->rank}}</td>
                    <td>{{$user->first_name}}</td>
                    <td>{{$user->first_name}}</td>
                </tr>
                <tr>
                    <td>
                        <button class="button button-primary" type="submit">DELETE</button>
                    </td>
                    <td>
                        <button><a href="{{ URL::previous() }}" class="button button-primary">EXIT</a></button>
                    </td>
                </tr>
            </table>
        </form>
    </div>
@endsection
