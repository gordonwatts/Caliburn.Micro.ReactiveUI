This library aims to help mesh Caliburn.Micro and ReactiveUI together.
The approach is to take things implemented on top of ReactiveObject and see
how far we can get having them implemented on top of Caliburn.Micro things.

What is there so far:

ToPropertyCM - this is the same as ReactiveUI's ToProperty, but for a
PropertyChangedBase as the base.