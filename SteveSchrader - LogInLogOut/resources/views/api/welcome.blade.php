@extends('pagetemplate')
@section('content')
    <div>
        @if ($user->admin)
            <!-- List users in database -->
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
                    @forelse ($users as $user)
                        @if (!$user->admin)
                            <div>
                                <tr>
                                    <td>{{$user->service_number}}</td>
                                    <td>{{$user->rank}}</td>
                                    <td>{{$user->first_name}}</td>
                                    <td>{{$user->last_name}}</td>

                                    <!-- Display Modify & De-list buttons at end of each line -->
                                    <td>
                                        <form method="GET" action="{{route('user.edit', $user)}}">
                                            @csrf
                                            <button class="button" type="submit">MODIFY</button>
                                        </form>
                                    </td>
                                    <td>
                                        <form method="GET" action="{{route('user.delete', $user)}}">
                                            @csrf
                                            <button class="button delete" type="submit">DE-LIST</button>
                                        </form>
                                    </td>

                                </tr>
                            </div>

                        @endif
                    @empty
                        <p>No Staff Exist</p>
                    @endforelse
                </table>
            </div>
        @else
            <!-- Acknowledge user log-in -->
            <div class="cell">
                <h2 class="heading"><strong>WELCOME</strong></h2>
                <p>{{$user->service_number}}.{{$user->rank}}.{{$user->first_name}}.{{$user->last_name}}</p>
            </div>
        @endif
    </div>
@endsection
