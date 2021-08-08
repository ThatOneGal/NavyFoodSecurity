<?php

namespace App\Http\Controllers;

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
        $userRoles = UserRoles::all();
        return view('userRoles.index', ['userRoles' => $userRoles]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        return view('userRoles.create');
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        $userRoles = new UserRoles();
        $userRoles -> fill($request -> all());
        $userRoles -> save();
        return redirect(route('userRoles.index'));
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\UserRoles  $userRoles
     * @return \Illuminate\Http\Response
     */
    public function edit(UserRoles $userRoles)
    {
        return view('userRoles.edit', ['userRoles' => $userRoles]);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\UserRoles  $userRoles
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, UserRoles $userRoles)
    {
        $userRoles->fill($request->all());
        $userRoles->save();
        return redirect(route('userRoles.index'));
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\UserRoles  $userRoles
     * @return \Illuminate\Http\Response
     */
    public function destroy(UserRoles $userRoles)
    {
        $model = $userRoles;
        $model->delete();
        return redirect(route('userRoles.index'));
    }
}
