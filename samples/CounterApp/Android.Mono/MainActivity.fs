﻿// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace CounterApp.Android

open Android.App
open Android.Content.PM
open Android.Runtime
open Android.OS

open Fabulous.XamarinForms
open CounterApp
open Xamarin.Forms.Platform.Android

[<Activity(Label = "CounterApp",
           Icon = "@drawable/icon",
           Theme = "@style/MainTheme",
           MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    override this.OnCreate(bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- CounterApp.Android.Resource.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- CounterApp.Android.Resource.Layout.Toolbar

        base.OnCreate(bundle)
        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init(this, bundle)

        this.LoadApplication(Program.startApplication App.program)

    override this.OnRequestPermissionsResult(requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
