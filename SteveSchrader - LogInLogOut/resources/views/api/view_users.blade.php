@extends('pagetemplate')
@section('content')
    <div class="cell">
        <h2 class="heading"><strong>REQUISITIONS STAFF</strong></h2>
        <table style="width:60%">
            <tr>
                <h4>
                    <th width="15%">SERVICE NUMBER</th>
                    <th width="15%">RANK</th>
                    <th width="20%">FIRST NAME</th>
                    <th width="20%">LAST NAME</th>
                </h4>
            </tr>
            @foreach ($users as $user)
                @if ($user->admin == 0)
                    <div>
                        <tr>
                            <td>{{$user->service_number}}</td>
                            <td>{{$user->rank}}</td>
                            <td>{{$user->first_name}}</td>
                            <td>{{$user->last_name}}</td>
                        </tr>
                    </div>
                @endif
            @endforeach
        </table>
    </div>
@endsection
