<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Statuses') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto" style="align-content: center">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>

                    @foreach($status as $status)
                        <tr class="text-center">
                            <td>{{$status->id}}</td>
                            <td>{{$status->statusName}}</td>

                            <td>
                                <a href="{{route('status.edit', $status)}}" style="background: #efefef; border: black;">Edit</a>
                            </td>

                            <td>
                                <form method="POST" action="{{route('status.destroy', $status)}}">
                                    @method('DELETE')
                                    @csrf
                                    <button class="button button-red" type="submit" style="background: #efefef; border: black;">Delete</button>
                                </form>
                            </td>

                        </tr>

                    @endforeach
                    <div style="text-align: center; margin-top: 10px">
                        <a href="{{route('status.create')}}" style="background: #efefef; border: black;"
                           class="button">Create New</a>
                    </div>
                </table>
            </div>



        </div>
    </div>
</x-app-layout>


