<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Order:') }} {{$Order->id}}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <form style="text-align: center">
                    @csrf

                    <div> {{--Destination--}}
                        <div><label for="Location" style="font-weight: bold">Destination:</label></div>
                        <div>
                            <div>
                                <label for="Location">
                                    @foreach($locationList as $location)
                                        @if ($Order->LocationId == $location->id)
                                            {{$location->locationName}}
                                        @endif
                                    @endforeach
                                </label>
                            </div>
                        </div>
                    </div>

                    <div> {{--Status--}}
                        <div><label for="Status" style="font-weight: bold">Status:</label></div>

                        <div>
                            <label for="Status">
                                @foreach($statusList as $status)
                                    @if ($Order->StatusId == $status->id)
                                        {{$status->statusName}}
                                    @endif
                                @endforeach
                            </label>
                        </div>
                    </div>

                    <div> {{--Order Date--}}
                        <div>
                            <label for="OrderDate" style="font-weight: bold">Date Ordered:</label>
                        </div>
                        <div>
                            <label for="OrderDate" style="font-weight: bold">{{$Order->OrderDate}}</label>
                        </div>
                    </div>

                    <div> {{--Order Shipped--}}
                        <div>
                            <label for="OrderShipped" style="font-weight: bold">Date Shipped:</label>
                        </div>
                        <div>
                            <label for="OrderShipped" style="font-weight: bold">
                                @if($Order->OrderShipped == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderShipped}}
                                @endif </label>
                        </div>
                    </div>

                    <div> {{--Order Packed--}}
                        <div>
                            <label for="OrderPacked" style="font-weight: bold">Date Packed:</label>
                        </div>
                        <div>
                            <label for="OrderPacked" style="font-weight: bold">
                                @if($Order->OrderPacked == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderPacked}}
                                @endif
                            </label>
                        </div>
                    </div>

                    <div> {{--Packaged Qty--}}
                        <div>
                            <label for="PackageQty" style="font-weight: bold">Package Qty:</label>
                        </div>
                        <div>
                            <textarea name="PackageQty" id="PackageQty" cols="0"
                                      rows="0" readonly>{{$Order->PackageQty}}</textarea>
                        </div>

                    </div>

                    <div> {{--Order Name--}}
                        <div>
                            <label for="CustomerId" style="font-weight: bold">Order Recipient</label>
                        </div>

                        <div>
                            <input type="text" id="CustomerId"
                                   value="{{$Order->CustomerId }} {{--Variable for users details--}} " readonly>
                        </div>
                    </div>

                    <div>{{--Order Content--}}
                        <div>
                            <label for="Content" style="font-weight: bold">Content:</label>
                        </div>

                        <div>
                            <textarea name="Content" id="Content" cols="0" rows="0"
                                      readonly>{{$Order->Content}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes Storage--}}
                        <div>
                            <label for="NotesStorage" style="font-weight: bold">Notes:</label>
                        </div>
                        <div>
                            <textarea name="NotesStorage" id="NotesStorage" cols="0"
                                      rows="0" readonly>{{$Order->NotesStorage}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes Preparation--}}
                        <div>
                            <label for="NotesPreparation" style="font-weight: bold">Notes Preparation:</label>
                        </div>
                        <div>
                            <textarea name="NotesPreparation" id="NotesPreparation" cols="0"
                                      rows="0" readonly>{{$Order->NotesPreparation}}</textarea>
                        </div>
                    </div>

                    <div style="margin-top: 10px">
                        <a href="{{route('order.edit', $Order)}}">Edit</a>
                    </div>
                </form>
                <div>
                    {!! QrCode::size(250)->format('svg')->generate($Order, public_path('images/qrcode.svg')) !!}
                    <img src="{{url('/images/qrcode.svg')}}"/>
                </div>
            </div>
        </div>


    </div>
    </div>
    </div>

</x-app-layout>
