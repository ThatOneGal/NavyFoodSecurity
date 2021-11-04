<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Create Order') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">


                <form style="text-align: center" action="{{route('order.store')}}" method="POST">
                    @csrf

                    <div>
                        <h1>Ordering Form</h1>
                    </div>
                    <div> {{--Destination--}}
                        <div>
                            <label for="Location">Destination:</label>
                        </div>

                        <div>
                            {{--<input type="select" name="Location" list="LocationList" --}}{{--Location variable--}}{{--/>--}}

                            <select name="LocationId" id="LocationId">
                                @foreach($locationList as $location)
                                    <option value="{{$location->id}}">{{$location->locationName}}</option>
                                @endforeach

                            </select>
                        </div>
                    </div>



                    <div> {{--Order Name--}}
                        <div>
                            <label for="CustomerId">Order Recipient</label>
                        </div>

                        <div>
                            <input type="text" id="CustomerId" value="{{Auth::user()->id }} {{--Variable for users details--}} " readonly>
                        </div>
                    </div>

                    <div>{{--Order Content--}}
                        <div>
                            <label for="Content">Content:</label>
                        </div>

                        <div>
                            <textarea name="Content" id="Content" cols="0" rows="0">{{--content list of data--}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes--}}
                        <div>
                            <label for="NotesStorage">Notes:</label>
                        </div>
                        <div>
                            <textarea name="NotesStorage" id="NotesStorage" cols="0" rows="0">{{--content list of data--}}</textarea>
                        </div>

                    </div>
                    <div>
                        <input type="submit" value="Submit">
                        <br>
                        <input type="reset" value="Cancel">

                    </div>

                </form>


            </div>
        </div>
    </div>
</x-app-layout>
