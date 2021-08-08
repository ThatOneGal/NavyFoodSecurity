<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\UserRoles;
use Illuminate\Http\Request;

class UserRolesController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $roles = UserRoles::all();
        return response()->json($roles, 200);
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
                'RoleName'=>'required|max:32'
            ]
        );
        $roles = UserRoles::create($request->all());

        return response()->json($roles, 201);
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Status  $roles
     * @return \Illuminate\Http\Response
     */
    public function show(UserRoles $roles)
    {
        return response()->json($roles, 200);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\Status  $roles
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, UserRoles $roles)
    {
        $this->validate(
            $request,
            [
                'RolesName'=>'required|max:32'
            ]
        );
        $roles->update($request->all());
        return response()->json($roles, 201);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Status  $roles
     * @return \Illuminate\Http\Response
     */
    public function destroy(UserRoles $roles)
    {
        $roles->delete();
        return response()->json(null, 200);
    }
}
