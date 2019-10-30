﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class AEntrance : AHotBase
{
	protected override void InitComponents()
	{
		PreDownloadResources();
	}

	private string[] preloadResources = new string[] {
		  "ui/uilogin.ab"

		, "ui/uirank.ab"
		, "ui/uialert.ab"
		, "ui/uimain.ab"
		, "ui/uiwait.ab"
		, "ui/uicreateavatar.ab"
		, "ui/uicommonwait.ab"
		, "ui/uiloading.ab"
		, "ui/uiregister.ab"
	};
	private void PreDownloadResources()
	{
		UHotAssetBundleLoader.Instance.OnDownloadResources(new List<string> { Utils.GetPlatformFolder(Application.platform)
			, Utils.GetPlatformFolder(Application.platform)+ ".manifest" }, () =>
		{
			UHotAssetBundleLoader.Instance.OnDownloadResources(new List<string> { "ui/uiloading.ab" }, () =>
		   {
			   LoadUI<UILoading>();

			   UHotAssetBundleLoader.Instance.OnDownloadResources(new List<string>(preloadResources), () =>
			   {
				   UILoading.Instance?.OnUnloadThis();

				   LoadUI<UILogin>();
			   }, null);
		   }, null);
		}, null);
	}
}

