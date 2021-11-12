<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Order:') }} {{$OrderNum->id}}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <form style="text-align: center; margin-top: 10px; margin-bottom: 10px">
                    @csrf

                    <div> {{--Destination--}}
                        <div><label for="Location">Destination:</label></div>
                        <div>
                            <div>
                                <label for="Location">
                                    @foreach($locationList as $location)
                                        @if ($OrderNum->LocationId == $location->id)
                                            {{$location->locationName}}
                                        @endif
                                    @endforeach
                                </label>
                            </div>
                        </div>
                    </div>

                    <div> {{--Status--}}
                        <div><label for="Status">Status:</label></div>

                        <div>
                            <label for="Status">
                                @foreach($statusList as $status)
                                    @if ($OrderNum->StatusId == $status->id)
                                        {{$status->statusName}}
                                    @endif
                                @endforeach
                            </label>
                        </div>
                    </div>

                    <div> {{--Order Date--}}
                        <div>
                            <label for="OrderDate">Date Ordered:</label>
                        </div>
                        <div>
                            <label for="OrderDate">{{$OrderNum->OrderDate}}</label>
                        </div>
                    </div>

                    <div> {{--Order Shipped--}}
                        <div>
                            <label for="OrderShipped">Date Shipped:</label>
                        </div>
                        <div>
                            <label for="OrderShipped">
                                @if($OrderNum->OrderShipped == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$OrderNum->OrderShipped}}
                                @endif </label>
                        </div>
                    </div>

                    <div> {{--Order Packed--}}
                        <div>
                            <label for="OrderPacked">Date Packed:</label>
                        </div>
                        <div>
                            <label for="OrderPacked">
                                @if($OrderNum->OrderPacked == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$OrderNum->OrderPacked}}
                                @endif
                            </label>
                        </div>
                    </div>

                    <div> {{--Packaged Qty--}}
                        <div>
                            <label for="PackageQty">Package Qty:</label>
                        </div>
                        <div>
                            <textarea name="PackageQty" id="PackageQty" cols="0"
                                      rows="0" readonly>{{$OrderNum->PackageQty}}</textarea>
                        </div>

                    </div>

                    <div> {{--Order Name--}}
                        <div>
                            <label for="CustomerId">Order Recipient</label>
                        </div>

                        <div>
                            <input type="text" id="CustomerId"
                                   value="{{$OrderNUm->CustomerId }} {{--Variable for users details--}} " readonly>
                        </div>
                    </div>

                    <div>{{--Order Content--}}
                        <div>
                            <label for="Content">Content:</label>
                        </div>

                        <div>
                            <textarea name="Content" id="Content" cols="0" rows="0"
                                      readonly>{{$OrderNum->Content}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes Storage--}}
                        <div>
                            <label for="NotesStorage">Notes:</label>
                        </div>
                        <div>
                            <textarea name="NotesStorage" id="NotesStorage" cols="0"
                                      rows="0" readonly>{{$OrderNum->NotesStorage}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes Preparation--}}
                        <div>
                            <label for="NotesPreparation">Notes Preparation:</label>
                        </div>
                        <div>
                            <textarea name="NotesPreparation" id="NotesPreparation" cols="0"
                                      rows="0" readonly>{{$OrderNum->NotesPreparation}}</textarea>
                        </div>
                    </div>

                    <div style="margin-top: 10px">
                        <a href="{{route('order.edit', $OrderNum)}}">Edit</a>
                    </div>
                </form>
            </div>
        </div>

        <div>
            {!! QrCode::size(250)->format('svg')->generate($OrderNum, public_path('images/qrcode.svg')) !!}
            <img src="{{url('/images/qrcode.svg')}}"/>
        </div>

    </div>
    </div>
    </div>

</x-app-layout>
