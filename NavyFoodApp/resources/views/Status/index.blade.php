<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Statuses') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto" style="text-align: center; mso-cellspacing: 20px">
                    {{--Table header--}}
                    <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                    </thead>
                    <tbody>
                    @foreach($status as $status)
                        <tr class="text-center">
                            <td>{{$status->id}}</td>
                            <td>{{$status->statusName}}</td>

                            <td>
                                <a href="{{route('status.edit', $status)}}" style="background: #efefef; border: black;">Edit</a>

                                <form method="POST" action="{{route('status.destroy', $status)}}">
                                    @method('DELETE')
                                    @csrf
                                    <button class="button button-red" type="submit"
                                            style="background: #efefef; border: black;">Delete
                                    </button>
                                </form>
                            </td>
                        </tr>

                    @endforeach
                    </tbody>
                </table>

                <div style="text-align: center; margin-top: 10px">
                    <a href="{{route('status.create')}}" style="background: #efefef; border: black;"
                       class="button">Create New</a>
                </div>
            </div>
        </div>
    </div>
</x-app-layout>


