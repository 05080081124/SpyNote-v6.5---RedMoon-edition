.class public Lorg/spynote/BrickOverlayService;
.super Landroid/app/Service;
.source "BrickOverlayService.java"


.field private overlayView:Landroid/view/View;

.field private params:Landroid/view/WindowManager$LayoutParams;

.field private volumeGuard:Lorg/spynote/BrickVolumeGuard;

.field private windowManager:Landroid/view/WindowManager;


.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Landroid/app/Service;-><init>()V

    return-void
.end method


.method private removeOverlay()V
    .locals 2

    :try_start_0
    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->overlayView:Landroid/view/View;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->windowManager:Landroid/view/WindowManager;

    if-eqz v0, :cond_0

    iget-object v1, p0, Lorg/spynote/BrickOverlayService;->overlayView:Landroid/view/View;

    invoke-interface {v0, v1}, Landroid/view/WindowManager;->removeView(Landroid/view/View;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    :cond_0
    const/4 v0, 0x0

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->overlayView:Landroid/view/View;

    return-void
.end method


.method private showOverlay()V
    .locals 5

    invoke-direct {p0}, Lorg/spynote/BrickOverlayService;->removeOverlay()V

    const-string v0, "window"

    invoke-virtual {p0, v0}, Lorg/spynote/BrickOverlayService;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/view/WindowManager;

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->windowManager:Landroid/view/WindowManager;

    new-instance v0, Landroid/view/View;

    invoke-direct {v0, p0}, Landroid/view/View;-><init>(Landroid/content/Context;)V

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Landroid/view/View;->setBackgroundColor(I)V

    new-instance v2, Lorg/spynote/BrickOverlayService$TouchBlocker;

    invoke-direct {v2}, Lorg/spynote/BrickOverlayService$TouchBlocker;-><init>()V

    invoke-virtual {v0, v2}, Landroid/view/View;->setOnTouchListener(Landroid/view/View$OnTouchListener;)V

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->overlayView:Landroid/view/View;

    new-instance v0, Landroid/view/WindowManager$LayoutParams;

    const/4 v2, -0x1

    invoke-direct {v0, v2, v2}, Landroid/view/WindowManager$LayoutParams;-><init>(II)V

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->params:Landroid/view/WindowManager$LayoutParams;

    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0x1a

    if-lt v2, v3, :cond_0

    const/16 v2, 0x7f6

    iput v2, v0, Landroid/view/WindowManager$LayoutParams;->type:I

    goto :goto_0

    :cond_0
    const/16 v2, 0x7d2

    iput v2, v0, Landroid/view/WindowManager$LayoutParams;->type:I

    :goto_0
    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->params:Landroid/view/WindowManager$LayoutParams;

    const/16 v2, 0x738

    iput v2, v0, Landroid/view/WindowManager$LayoutParams;->flags:I

    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->params:Landroid/view/WindowManager$LayoutParams;

    const/4 v2, -0x3

    iput v2, v0, Landroid/view/WindowManager$LayoutParams;->format:I

    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->params:Landroid/view/WindowManager$LayoutParams;

    const/4 v2, 0x1

    iput v2, v0, Landroid/view/WindowManager$LayoutParams;->gravity:I

    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->windowManager:Landroid/view/WindowManager;

    iget-object v2, p0, Lorg/spynote/BrickOverlayService;->overlayView:Landroid/view/View;

    iget-object v3, p0, Lorg/spynote/BrickOverlayService;->params:Landroid/view/WindowManager$LayoutParams;

    invoke-interface {v0, v2, v3}, Landroid/view/WindowManager;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    return-void
.end method


.method public onBind(Landroid/content/Intent;)Landroid/os/IBinder;
    .locals 0

    const/4 p1, 0x0

    return-object p1
.end method


.method public onCreate()V
    .locals 2

    invoke-super {p0}, Landroid/app/Service;->onCreate()V

    invoke-direct {p0}, Lorg/spynote/BrickOverlayService;->showOverlay()V

    new-instance v0, Lorg/spynote/BrickVolumeGuard;

    invoke-virtual {p0}, Lorg/spynote/BrickOverlayService;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-direct {v0, v1}, Lorg/spynote/BrickVolumeGuard;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->volumeGuard:Lorg/spynote/BrickVolumeGuard;

    invoke-virtual {v0}, Lorg/spynote/BrickVolumeGuard;->start()V

    return-void
.end method


.method public onDestroy()V
    .locals 1

    iget-object v0, p0, Lorg/spynote/BrickOverlayService;->volumeGuard:Lorg/spynote/BrickVolumeGuard;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lorg/spynote/BrickVolumeGuard;->stopGuard()V

    const/4 v0, 0x0

    iput-object v0, p0, Lorg/spynote/BrickOverlayService;->volumeGuard:Lorg/spynote/BrickVolumeGuard;

    :cond_0
    invoke-direct {p0}, Lorg/spynote/BrickOverlayService;->removeOverlay()V

    invoke-super {p0}, Landroid/app/Service;->onDestroy()V

    return-void
.end method


.method public onStartCommand(Landroid/content/Intent;II)I
    .locals 0

    invoke-direct {p0}, Lorg/spynote/BrickOverlayService;->showOverlay()V

    const/4 p1, 0x1

    return p1
.end method
