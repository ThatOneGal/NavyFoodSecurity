<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Location;
use Illuminate\Http\Request;

class LocationController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $locations = Location::all();
        return response()->json($locations, 200);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        $this->validate(
            $request,
            [
                'locationName'=>'required|max:32'
            ]
        );
        $locations = Location::create($request->all());

        return response()->json($locations, 201);
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Location  $location
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $Location = Location::find($id);
        if (!$Location) {
            abort(404);
        }

        return response()->json($Location, 200);
    }



        /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\Location  $location
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Location $location)
    {
        $this->validate(
            $request,
            [
                'locationName'=>'required|max:32'
            ]
        );
        $location->update($request->all());
        return response()->json($location, 201);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Location  $location
     * @return \Illuminate\Http\Response
     */
    public function destroy(Location $location)
    {
        $location->delete();
        return response()->json(null, 200);
    }
}
