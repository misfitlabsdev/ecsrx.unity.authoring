# ecsrx.unity.authoring

A plugin for [EcsRx](https://github.com/EcsRx/ecsrx) / [EcsRx.Unity](https://github.com/EcsRx/ecsrx.unity) that allows authoring entity components in the Unity Editor similarly to the authoring functionality in the Unity.Entities preview package for DOTS. By adding the `ConvertToEntity` behaviour to a GameObject and adding fields to custom implementations of `IComponentConversion` you can define your component data in the editor like you normally would and have it automatically converted into entities for EcsRx.

# Requirements

* Unity 2018 (.net 4.5)
* ecsrx
* ecsrx.unity
* Zenject 6+
